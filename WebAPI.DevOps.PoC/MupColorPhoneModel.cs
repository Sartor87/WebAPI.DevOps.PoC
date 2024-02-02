namespace WebAPI.DevOps.PoC
{
    public class MupColorPhoneModel
    {
        public MupColorPhoneModel()
        {
            this.MupColors = new List<string>();
            this.PhoneModels = new List<string>();
            this.ModelColors = new Dictionary<string, List<PhoneColor>>();
        }

        public IList<string> MupColors { get; set; }
        public IList<string> PhoneModels { get; set; }
        public IDictionary<string, List<PhoneColor>> ModelColors { get; set; }
    }
}
