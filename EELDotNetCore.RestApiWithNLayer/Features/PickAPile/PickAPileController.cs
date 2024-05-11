using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EELDotNetCore.RestApiWithNLayer.Features.PickAPile
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickAPileController : ControllerBase
    {
        private async Task<MainDto> GetDataAsync()
        {
            string jsonstr = await System.IO.File.ReadAllTextAsync("PickAPileData.json");
            var model = JsonConvert.DeserializeObject<MainDto>(jsonstr);
            return model!;
        }
        [HttpGet("Questions")]
        public async Task<IActionResult> Questions()
        {
            var model = await GetDataAsync();
            return Ok(model.Questions);
        }

        [HttpGet("Answers")]
        public async Task<IActionResult> Answers()
        {
            var model = await GetDataAsync();
            return Ok(model.Answers);
        }
        [HttpGet("{QuestionId}/{AnswerId}")]
        public async Task<IActionResult> answerPile(int QuestionId, int AnswerId)
        {
            var model = await GetDataAsync();
            return Ok(model.Answers.FirstOrDefault(x => x.QuestionId == QuestionId && x.AnswerId == AnswerId));
        }

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

    }
}
