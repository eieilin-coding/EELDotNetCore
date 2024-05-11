using Newtonsoft.Json;

Console.WriteLine("Hello, World!");
string jsonstr = await File.ReadAllTextAsync("PickAPileData.json");
var model = JsonConvert.DeserializeObject<MainDto>(jsonstr);

//Console.WriteLine(jsonstr);

foreach (var question in model!.Questions)
{
    Console.WriteLine(question.QuestionId);
}
// Json to C# ??? package
// C# to JSON

public class MainDto
{
    public Question[] Questions { get; set; }
    public Answer[] Answers { get; set; }
}

public class Question
{
    public int QuestionId { get; set; }
    public string QuestionName { get; set; }
    public string QuestionDesp { get; set; }
}

public class Answer
{
    public int AnswerId { get; set; }
    public string AnswerImageUrl { get; set; }
    public string AnswerName { get; set; }
    public string AnswerDesp { get; set; }
    public int QuestionId { get; set; }
}


