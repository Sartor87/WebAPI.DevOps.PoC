namespace WebAPI.DevOps.PoC.Repos
{
    public class MupColorPhoneRepo
    {
        public MupColorPhoneRepo()
        {

        }

        public MupColorPhoneModel MupColorsModelsAndModelColors(IList<IList<object>> rows)
        {
            var result = new MupColorPhoneModel();

            for (var cells = 0; cells < rows.Count; cells++)
            {
                // We fetch the mupColor names as they are infinite number
                // The first row is the header with unknown number of mup colors
                if (cells == 0)
                {
                    var headers = rows[cells];
                    for (var headerCell = 1; headerCell < headers.Count; headerCell++)
                    {
                        // use this type of cast to string to avoid null reference exception
                        result.MupColors.Add((string)headers[headerCell]);
                    }
                }
                else
                {
                    // Extract phone row data by cells
                    var phoneData = rows[cells];
                    // Get the first cell - we assume that it is always the model name
                    var phoneModel = phoneData[0];
                    // Define phone models mapping class collection for the phone
                    var phoneColors = new List<PhoneColor>();
                    for (var phoneColor = 1; phoneColor < phoneData.Count; phoneColor++)
                    {
                        // Map mup colors to phone model color based on the retrieved mup colors from the header row
                        phoneColors.Add(new PhoneColor
                        {
                            MupColor = (string)result.MupColors[phoneColor - 1],
                            ColorName = (string)phoneData[phoneColor]
                        });
                    }
                    // Add phone model -> colors mapping only if the color is available as option for this phone model
                    result.ModelColors.Add((string)phoneModel, phoneColors.Where(c => !String.IsNullOrWhiteSpace(c.ColorName)).ToList());
                    result.PhoneModels.Add((string)phoneModel);
                }
            }

            return result;
        }
    }
}
