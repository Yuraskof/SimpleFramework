namespace Task3_Framework
{
    public class UserModel
    {
        public string GameName { get; set; }
        public string ReleaseDate { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal FullPrice { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            UserModel other = (UserModel)obj; ;

            return GameName.Equals(other.GameName) && ReleaseDate.Equals(other.ReleaseDate) && 
                   DiscountedPrice.Equals(other.DiscountedPrice) && FullPrice.Equals(other.FullPrice);
        }
    }
}

    
