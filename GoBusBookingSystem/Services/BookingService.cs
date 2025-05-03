using GoBusBookingSystem.Models;
using GoBusBookingSystem.Respository;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System.Text;

namespace GoBusBookingSystem.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepositotry;

        public BookingService(IBookingRepository bookingRepositotry)
        {
            _bookingRepositotry = bookingRepositotry;
        }

        public async Task<List<Booking>> AddBookingAsync(List<Booking> bookingList)
        {
            return await _bookingRepositotry.AddBulkBookingsAsync(bookingList);
        }


        public async Task<BookingTrip> AddBookingTripAsync(BookingTrip trip)
        {
            return await _bookingRepositotry.CreateTripAsync(trip);
        }

        public async Task<List<Booking>> CreateBookingAsync(List<Booking> bookingList, int tripId)
        {
            return await _bookingRepositotry.CreateBookingAsync(bookingList,tripId);
        }


        public async Task<byte[]> GenerateReservationsPdfAsync()
        {
            var reservations = await _bookingRepositotry.GetCompletedReservationsasync();

            //Generate  html table
            var htmlContent = GenerateCompletedReservationHtml(reservations);

            //convert HTML to pdf 
            return GeneratePdfForHtml(htmlContent);

        }
        private string GenerateCompletedReservationHtml(List<Booking> reservations)
        {
            var sb = new StringBuilder();

            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<style>");
            sb.AppendLine("table { width: 100%; border-collapse: collapse; }");
            sb.AppendLine("th, td { border: 1px solid black; padding: 8px; text-align: center; }");
            sb.AppendLine("th { background-color: #f2f2f2; }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<h2>Completed Reservations</h2>");
            sb.AppendLine("<table>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th>Ticket Number</th>");
            sb.AppendLine("<th>Seat Number</th>");
            sb.AppendLine("<th>Booking Date</th>");
            sb.AppendLine("<th>Status</th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (var reservation in reservations)
            {
                // Only include completed reservations (you can filter based on your logic)
                if (reservation.BookingStatus == "Booked"  || reservation.BookingStatus == "Cancelled") // Assuming you have a Status field
                {

                    string seatList = string.Join(", ", reservation.SeatNumber);
                    string rowStyle = reservation.BookingStatus == "Cancelled" ? "style='color:red;'" : "";
                    sb.AppendLine("<tr>");
                    sb.AppendLine($"<td>{reservation.TicketNumber}</td>");
                    sb.AppendLine($"<td>{seatList}</td>");
                    sb.AppendLine($"<td>{reservation.BookingDate:yyyy-MM-dd}</td>");
                    sb.AppendLine($"<td>{reservation.BookingStatus}</td>");
                    sb.AppendLine("</tr>");
                }
            }

            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }

        private byte[] GeneratePdfForHtml(string htmlContent)
        {
            using (var memoryStream = new MemoryStream())
            {
                // 1. Create a new Document (PDF settings)
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);

                // 2. Create PDF writer instance to write into memory
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                // 3. Open the document
                document.Open();

                // 4. Parse the HTML content into the PDF document
                using (var htmlStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(htmlContent)))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlStream, null, System.Text.Encoding.UTF8);
                }

                // 5. Close the document
                document.Close();

                // 6. Return the PDF as byte array
                return memoryStream.ToArray();
            }
        }
    }
    
}
