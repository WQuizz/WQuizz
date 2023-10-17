import { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import "../Styles/quizelement.css";
import "../Styles/animated-background.css";
import quizImage from "../Images/quiz-time.png";


export default function QuizElement(props) {
  const [quizResult, setQuizResult] = useState([]);
  const [quizQuestions, setQuizQuestions] = useState([]);
  const [quizAnswers, setQuizAnswers] = useState([]);

  const [currentQuestion, setCurrentQuestion] = useState("");

  const [questionNumberTracker, setQuestionNumberTracker] = useState(1);

  const [endofQuiz, setEndOfQuiz] = useState(false);

  async function FetchAnswers()
  {
    try{
      const response = await fetch(`http://localhost:9000/api/Answer/GetByQuestionId/${quizQuestions[0].id}`);
      const data = await response.json();
      if(response.ok)
      {
        setQuizAnswers(data);
        console.log(data);
      }
     

    }catch(err)
    {
      console.error(err);
    }
  }


async function FetchQuestions()
{
  try{
    console.log(quizResult.id);
    const response = await fetch(`http://localhost:9000/api/Question/GetByQuizId/${quizResult.id}`)
    const data =  await response.json();
    if(response.ok)
    {
      setQuizQuestions(data);
      setCurrentQuestion(data[0].questionContent)
      console.log(data);
    }
   

  }catch(err){
    console.error(err);
  }

}


  async function FetchSearchInput() {
    try {
      console.log(props.quizName);
      const response = await fetch(
        `http://localhost:9000/api/Quiz/GetQuizByName?name=${props.quizName}`
      );
      const data = await response.json();
      if(response.ok)
      {
        console.log(data);
        setQuizResult(data);
        console.log(quizResult);
      }
      
    } catch (err) {
      console.error(err);
    }
  }


  useEffect(() => {
    FetchSearchInput();
  }, []);

  useEffect(() => {
    FetchQuestions();
  }, [quizResult])

  useEffect(() =>{
    FetchAnswers();
  }, [quizQuestions])

  const handleClick = () => {


    if(quizQuestions.length == questionNumberTracker)
    {
      setEndOfQuiz(true);
      console.log("END OF QUIZ");
    }
    else{

      setQuestionNumberTracker((prevState) => {
        return prevState + 1;
      });
  
      setCurrentQuestion(quizQuestions[questionNumberTracker].questionContent)
    }

   
  }




  return (
    <>
      {quizQuestions && quizResult && quizAnswers && quizQuestions.length > 0 && quizAnswers.length > 0 && endofQuiz == false ? (
        <div className="maincontainer animated-background">
          <div className="quiz-time-image-container"><img className="quiz-time-image" src={quizImage}></img></div>
          <div className="quiz-container">
          <div className="quiz-title">{quizResult.quizName}</div>
          <div className="quiz-question">{currentQuestion}</div>
          <div className="quiz-answers">
            <div className="answer-row first-row"> 
            <button className="answer" onClick={(e) => handleClick()}>{quizAnswers[0].answerContent}</button>
            <button className="answer" onClick={(e) => handleClick()}>{quizAnswers[1].answerContent}</button>
            </div>
          <div className="answer-row second-row"> 
          <button className="answer" onClick={(e) => handleClick()}>{quizAnswers[2].answerContent}</button>
            <button className="answer" onClick={(e) => handleClick()}>{quizAnswers[3].answerContent}</button>
          </div>
          </div>
          </div>
          </div>
      ) : (<div>END OF QUIZ</div>)}
    </>
  );
}
