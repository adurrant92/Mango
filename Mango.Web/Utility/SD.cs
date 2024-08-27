namespace Mango.Web.Utility
{
    public class SD
    {
        // stores the url address from app settings
        public static string CouponAPIBase {  get; set; }
        public enum ApiType
        {
            GET,
            POST, 
            PUT,
            DELETE
        }
    }
}
