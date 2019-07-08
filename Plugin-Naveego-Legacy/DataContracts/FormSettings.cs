namespace Plugin_Naveego_Legacy.DataContracts
{
    public class FormSettings
    {
        public string OAuthClientId { get; set; }
        
        public string OAuthClientSecret { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Had to add this because we had a decimal field that was nullable
        // however had 0.0000 in all the values.  Since we couldn't distinguish
        // between when a 0 represents null, this setting makes it so we can 
        // overcome this
        public string DecimalsThatAreNotReallyNullable { get; set; }
    }
}