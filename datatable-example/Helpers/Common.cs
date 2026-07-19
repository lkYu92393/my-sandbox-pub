namespace DataTableTest.Helpers
{
    public static class Common
    {
        public static string GetRandomName(int lengthOfStr = 6)
        {
            string charList = "abcdefghijklmnopqrstuvwxyz";
            Random rnd = new Random();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < lengthOfStr; i++)
            {
                if (i == 0)
                {
                    sb.Append(charList[rnd.Next(charList.Length)].ToString().ToUpper());
                }
                else
                {
                    sb.Append(charList[rnd.Next(charList.Length)]);
                }
            }
            return sb.ToString();
        }
        public static string GetRandomNumberID(int lengthOfId = 6)
        {
            string charList = "0123456789";
            Random rnd = new Random();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < lengthOfId; i++)
            {
                sb.Append(charList[rnd.Next(charList.Length)]);
            }
            return sb.ToString();
        }
    }
}
