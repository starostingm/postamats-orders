using Orders.BusinessLogic.Validators.PostamatNumberValidator.Interfaces;

namespace Orders.BusinessLogic.Validators.PostamatNumberValidator
{
    public class PostamatNumberValidator : IPostamatNumberValidator
    {
        public bool IsValid(string postamatNumber)
        {
            var prefix = "PT-";
            if (!postamatNumber.StartsWith(prefix))
                return false;

            var possibleNumbersString = postamatNumber.Substring(prefix.Length);
            if (possibleNumbersString.Length != 4)
                return false;

            foreach (var possibleNumber in possibleNumbersString)
            {
                if (!int.TryParse(new[] { possibleNumber }, out int number))
                    return false;

                if (number < 0 || number > 9)
                    return false;
            }

            return true;
        }
    }
}
