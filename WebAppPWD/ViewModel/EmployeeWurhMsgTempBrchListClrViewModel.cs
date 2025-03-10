namespace WebAppPWD.ViewModel
{
    public class EmployeeWurhMsgTempBrchListClrViewModel
    {
        //Hide Model Structure ,Select specific Property to send
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Msg { get; set; }
        public string Color { get; set; }
        public int Temp { get; set; }
        public List<string> Branches { get; set; }
    }
}
