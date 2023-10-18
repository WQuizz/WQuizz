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

  const [questionNumberTracker, setQuestionNumberTracker] = useState(0);

  const [endofQuiz, setEndOfQuiz] = useState(false);

  const [correctAnswers, setCorrectAnswers] = useState([]);

  const [selectedAnswers, setSelectedAnswers] = useState([]);

  const [points, setPoints] = useState(0);


  async function FetchAnswers()
  {
    try{
      const response = await fetch(`http://localhost:9000/api/Answer/GetByQuestionId/${quizQuestions[questionNumberTracker].id}`);
      const data = await response.json();
      if(response.ok)
      {
        setQuizAnswers(data);
        setCurrentQuestion(quizQuestions[questionNumberTracker].questionContent);
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
      setCurrentQuestion(data[questionNumberTracker].questionContent)
    }
   

  }catch(err){
    console.error(err);
  }

}


  async function FetchSearchInput() {
    try {
      const response = await fetch(
        `http://localhost:9000/api/Quiz/GetQuizByName?name=${props.quizName}`
      );
      const data = await response.json();
      if(response.ok)
      {
        setQuizResult(data);
      }
      
    } catch (err) {
      console.error(err);
    }
  }


  async function FetchCorrectAnswers(){
    try {
      const response = await fetch(`http://localhost:9000/api/Answer/IsCorrect/${quizQuestions[questionNumberTracker].id}`);
      const data = await response.json();

      if(response.ok){
        setCorrectAnswers(data);
        console.log("CORRECT ANSWERS",data);
      } 
      
    } catch (error) {
      console.error(error);
    }
  }

  useEffect(()=>{
    FetchCorrectAnswers();
  },[])
  
  useEffect(() => {
    FetchSearchInput();
  }, []);

  useEffect(() => {
    FetchQuestions();
  }, [quizResult])

  useEffect(() => {
    FetchAnswers();
  }, [quizQuestions, questionNumberTracker]);

  const handleClick = (e) => {

  
  

    console.log(quizAnswers.find(answer => answer.answerContent == e.target.textContent).id == correctAnswers[0]);

   quizAnswers.find(answer =>{ 
    if(correctAnswers && answer.answerContent == e.target.textContent.id == correctAnswers[0])
    { 
      console.log("xd")
    }
    })
   
    // console.log("CORRECT ANSWER");
    // setPoints((prev) => {
    //   return prev + 1;
    // })
   



    if(quizQuestions.length - 1 == questionNumberTracker)
    {
      setEndOfQuiz(true);
    }
    else{
      setQuestionNumberTracker((prev) => {
        return prev + 1;
      })
    }

    
  }

 
useEffect(() => {
console.log("QUIZ QUESTIONS:" , quizQuestions);
console.log("ANSWERS FOR QUESTION:", quizAnswers)
console.log("CLICK NUMBER TRACKER:", questionNumberTracker);
console.log("CORRECT ASNWER FOR THE QUESTION:", correctAnswers);
console.log("POINTS", points);
console.log("CORRECT ANSWER!!!!!!!!!!!!!!!!!!! ", correctAnswers[0]);

}, [quizAnswers, quizQuestions, questionNumberTracker, correctAnswers, points])



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
            <button className="answer" onClick={(e) => handleClick(e)}>{quizAnswers[0].answerContent}</button>
            <button className="answer" onClick={(e) => handleClick(e)}>{quizAnswers[1].answerContent}</button>
            </div>
          <div className="answer-row second-row"> 
          <button className="answer" onClick={(e) => handleClick(e)}>{quizAnswers[2].answerContent}</button>
            <button className="answer" onClick={(e) => handleClick(e)}>{quizAnswers[3].answerContent}</button>
          </div>
          </div>
          </div>
          </div>
      ) : (<div>END OF QUIZ</div>)}
    </>
  );
}
