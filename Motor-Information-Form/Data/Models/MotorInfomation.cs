namespace Motor_Information_Form.Data.Models
{
    public class MotorInformation
    {
        public DateTime artEndDate { get; set; }
        public int co2Emissions { get; set; }
        public string colour { get; set; }
        public int engineCapacity { get; set; }
        public string fuelType { get; set; }
        public string make { get; set; }
        public bool markedForExport { get; set; }
        public string monthOfFirstRegistration { get; set; }
        public string motStatus { get; set; }
        public string registrationNumber { get; set; }
        public int revenueWeight { get; set; }
        public string taxDueDate { get; set; }
        public string taxStatus { get; set; }
        public string typeApproval { get; set; }
        public string wheelplan { get; set; }
        public int yearOfManufacture { get; set; }
        public string euroStatus { get; set; }
        public int realDrivingEmissions { get; set; }
        public DateTime dateOfLastV5CIssued { get; set; }

        public string DrivingBanCheck()
        {
            if (artEndDate == DateTime.MinValue)
            {
                return "No driving ban";
            }
            else
            {
                return artEndDate.ToString("dd/mm/yyyy HH:mm:ss");
            }
    }

    }
}
