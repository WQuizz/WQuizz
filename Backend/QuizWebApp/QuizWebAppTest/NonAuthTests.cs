using Microsoft.EntityFrameworkCore;
using Moq;
using QuizWebApp.DatabaseServices;
using QuizWebApp.DatabaseServices.Repositories;
using QuizWebApp.Models;
using QuizWebAppTest.TestContexts;

namespace QuizWebAppTest;

public class Tests
{
    private TestWQuizzDBContext _testDbContext;
    private IQuizRepository _quizRepository;
    private IQuestionRepository _questionRepository;
    private IAnswerRepository _answerRepository;
    [SetUp]
    public void Setup()
    {
        _testDbContext = new TestWQuizzDBContext();
        _quizRepository = new QuizRepository(_testDbContext);
        _questionRepository = new QuestionRepository(_testDbContext);
        _answerRepository = new AnswerRepository(_testDbContext);
    }

    [Test]
    public void DatabaseIsSeeded()
    {
        var allQuizzes = _quizRepository.GetAll();
        var allQuestions = _questionRepository.GetAll();
        var allAnswers = _answerRepository.GetAll();
        Assert.Multiple(() =>
        {
            Assert.Positive(allQuizzes.Count());
            Assert.Positive(allQuestions.Count());
            Assert.Positive(allAnswers.Count());
        });
    }
    
    #region Relation between Quiz and Question entities

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    public void GetQuestionsRelatedToQuiz(int quizId)
    {
        var quiz = _quizRepository.GetById(quizId);
        Assert.Multiple(() =>
        {
            foreach (var question in quiz.Questions)
            {
                Assert.That(question.Quiz, Is.EqualTo(quiz));
            }
        });
    }

    [Test]
    [TestCase(1)]
    public void RelatedQuizIncludesQuestionInQuestions(int questionId)
    {
        var question = _questionRepository.GetById(questionId);
        Assert.That(question.Quiz.Questions, Does.Contain(question));
    }
    
    #endregion

    #region Relation between Question and Answer entities

    [Test]
    [TestCase(1)]
    [TestCase(7)]
    public void GetAnswersRelatedToQuestion(int questionId)
    {
        var question = _questionRepository.GetById(questionId);
        Assert.Multiple(() =>
        {
            foreach (var answer in question.Answers)
            {
                Assert.That(answer.Question, Is.EqualTo(question));
            }
        });
    }

    [Test]
    [TestCase(1)]
    [TestCase(8)]
    [TestCase(11)]
    public void RelatedQuestionIncludesAnswerInAnswersProperty(int answerId)
    {
        var answer = _answerRepository.GetById(answerId);
        Assert.That(answer.Question.Answers, Does.Contain(answer));
    }
    #endregion

    [Test]
    [TestCase(1)]
    public void AllAnswersAreRelatedToTheGivenQuiz(int quizId)
    {
        var quiz = _quizRepository.GetById(quizId);
        Assert.Multiple(() =>
        {
            foreach (var question in quiz.Questions)
            {
                Assert.That(question.Answers.All(ans => ans.Question.Quiz == quiz), Is.True);
            }
        });
    }

    [Test]
    public void AllQuestionsHaveAtLeastOneCorrectAnswers()
    {
        var allQuestions = _questionRepository.GetAll();
        Assert.Multiple(() =>
        {
            foreach (var question in allQuestions)
            {
                Assert.That(question.Answers.Any(ans => ans.IsCorrect), Is.True);
            }
        });
    }
    [Test]
    public void QuizCRUDTest()
    {
        string newName = "NEW NAME";
        var quiz = _quizRepository.GetById(1);
        quiz.QuizName = newName;
        _quizRepository.Update(quiz);
        var updatedQuiz = _quizRepository.GetById(1);
        Assert.That(updatedQuiz.QuizName, Is.EqualTo(newName));
        var newQuiz = new Quiz
        {
            QuizName = updatedQuiz.QuizName.ToLower(),
            Difficulty = updatedQuiz.Difficulty,
            IsApproved = updatedQuiz.IsApproved,
            Popularity = updatedQuiz.Popularity,
            Rating = updatedQuiz.Rating,
            ThumbnailUrl = updatedQuiz.ThumbnailUrl
        };
        _quizRepository.Add(newQuiz);
        Assert.That(_quizRepository.GetByName(newName.ToLower()), Is.Not.Null);
        _quizRepository.Delete(_quizRepository.GetByName(newName.ToLower()));
        Assert.That(_quizRepository.GetByName(newName.ToLower()), Is.Null);
    }

    [Test]
    public void QuestionCRUDTest()
    {
        string newContent = "NEW CONTENT";
        var question = _questionRepository.GetById(1);
        question.QuestionContent = newContent;
        _questionRepository.Update(question);
        Assert.That(_questionRepository.GetById(1).QuestionContent, Is.EqualTo(newContent));
        string newQuestionContent = "THIS QUESTION WAS NEWLY CREATED";
        var newQuestion = new Question
        {
            QuestionContent = newQuestionContent,
            QuizId = question.QuizId
        };
        _questionRepository.Add(newQuestion);
        Assert.That(_questionRepository.GetAll().Last().QuestionContent, Is.EqualTo(newQuestionContent));
        _questionRepository.Delete(newQuestion);
        Assert.That(_questionRepository.GetAll().Last().QuestionContent, Is.Not.EqualTo(newQuestionContent));
    }
    [Test]
    public void AnswerCRUDTest()
    {
        string newContent = "NEW CONTENT";
        var answer = _answerRepository.GetById(1);
        answer.AnswerContent = newContent;
        _answerRepository.Update(answer);
        Assert.That(_answerRepository.GetById(1).AnswerContent, Is.EqualTo(newContent));
        string newAnswerContent = "THIS ANSWER WAS NEWLY CREATED";
        var newAnswer = new Answer
        {
            AnswerContent = newAnswerContent,
            IsCorrect = false,
            QuestionId = answer.QuestionId
        };
        _answerRepository.Add(newAnswer);
        Assert.That(_answerRepository.GetAll().Last().AnswerContent, Is.EqualTo(newAnswerContent));
        _answerRepository.Delete(newAnswer);
        Assert.That(_answerRepository.GetAll().Last().AnswerContent, Is.Not.EqualTo(newAnswerContent));
    }
}