namespace CodeGitz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create The "posts" Table
            //CreateTable();

            // Insert Records Into "posts"
            //InsertData();

            // Display Data Entries
            ReadTable();
        }

        static void CreateTable()
        {
            // Create a Table With Columns Id, Name and URL Where ID is The Primary Key
            var CreateStatement = @"CREATE TABLE IF NOT EXISTS posts (Id INTEGER NOT NULL UNIQUE, Name TEXT NOT NULL,Url TEXT NOT NULL,PRIMARY KEY(Id AUTOINCREMENT))";
            
            // Call the CreateTable Function From SQLiteOps.cs
            SQLiteOps.CreateTable(CreateStatement);
        }

        static void InsertData()
        {
            List<String> InsertStatements = new();
            InsertStatements.Add("INSERT INTO posts (Name,Url) VALUES ('C# - Debugging StackOverflow Exception','https://codegitz.com/c-debugging-stackoverflow-exception/');");
            InsertStatements.Add("INSERT INTO posts (Name,Url) VALUES ('C# - How To Convert JSON Array To List?','https://codegitz.com/c-how-to-convert-json-array-to-list/');");
            InsertStatements.Add("INSERT INTO posts (Name,Url) VALUES ('C# - How To Implement Shortcut Keys in Winforms?','https://codegitz.com/how-to-implement-shortcut-keys-in-winforms/');");

            SQLiteOps.InsertRecords(InsertStatements);
        }

        static void ReadTable()
        {

            List<Posts> CodeGitzPosts = SQLiteOps.ReadTable();

            foreach (Posts Post in CodeGitzPosts)
            {
                Console.WriteLine($"Post ID: {Post.Id} \nPost Title: {Post.Name} \nPost URL: {Post.Url}\n\n");
            }
        }
    }
}




