namespace EntityModel.Models

{
    public class Training : Job
    {
        public bool Graduation { get; set; } = false;
        private DateTime _graduationDate;

        public DateTime GraduationDate
        {
            get { return _graduationDate; }
            set
            {
                if (Graduation == true)
                {
                    _graduationDate = value;
                }
                else
                {
                    _graduationDate = DateTime.MinValue;
                }
            }

        }
       
    }
}
