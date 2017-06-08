using Dollar.Authentication.Domain;

namespace Dollar.Authentication.Data.Models.Extensions
{
    public static class PasswordExtensions
    {
        public static PasswordModel ToModel(this Password password)
        {
            return new PasswordModel
            {
                Hash = password.Hash,
                Salt = password.Salt,
                Version = password.Version,
                CreatedOn = password.CreatedOn
            };
        }

        public static Password ToDomain(this PasswordModel passwordModel)
        {
            if (passwordModel == null)
                return null;

            return new Password
            {
                Hash = passwordModel.Hash,
                Salt = passwordModel.Salt,
                Version = passwordModel.Version,
                CreatedOn = passwordModel.CreatedOn
            };
        }
    }
}