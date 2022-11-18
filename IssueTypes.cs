namespace Downstream
{
    public class IssueTypes
    {

        public static List<string> DisplayIssueTypes(string suggestion1, string suggestion2, string suggestion3)
        {

            List<string> issueTypeList = new List<string>();
            issueTypeList.Add(suggestion1);
            issueTypeList.Add(suggestion2);
            issueTypeList.Add(suggestion3);

            return issueTypeList;
        }



    }
}
