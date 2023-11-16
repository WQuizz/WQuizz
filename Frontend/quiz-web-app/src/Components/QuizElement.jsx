import { useState, useEffect } from "react";
import "../Styles/quizelement.css";
import "../Styles/animated-background.css";
import quizImage from "../Images/quiz-time.png";
import EndQuizElement from "./EndQuizElement";
import CountdownTimer from "./CountdownTimer.jsx";
import LoadingElement from "./LoadingElement.jsx";
import {APIUrl} from "../Files/APIUrl.js";

export default function QuizElement(props) {
  const [quizResult, setQuizResult] = useState([]);
  const [quizQuestions, setQuizQuestions] = useState([]);
  const [quizAnswers, setQuizAnswers] = useState([]);

  const [currentQuestion, setCurrentQuestion] = useState("");

  const [questionNumberTracker, setQuestionNumberTracker] = useState(0);

  const [endofQuiz, setEndOfQuiz] = useState(false);


  const [selectedAnswers, setSelectedAnswers] = useState([]);

  const [correctAnswerIds, setCorrectAnswerIds] = useState([]);
  const [correctAnswers, setCorrectAnswers] = useState([]);
  const [wrongAnswers, setWrongAnswers] = useState([]);

  const [points, setPoints] = useState(0);

  const [timeLimit, setTimeLimit] = useState(null);

  const [key, setKey] = useState(0);

  const [loading, setLoading] = useState(true);


  async function FetchAnswers()
  {
    try{
      
      const response = await fetch(APIUrl + `Answer/GetByQuestionId/${quizQuestions[questionNumberTracker].id}`);
      const data = await response.json();
      if(response.ok)
      {
        setLoading(false);
        setQuizAnswers(data);
        setCurrentQuestion(quizQuestions[questionNumberTracker].questionContent);
      }
     

    }catch(err)
    {
      console.error(err);
    }
  
  }

  
  async function FetchQuestions() {
    try {
      const response = await fetch(`${APIUrl}Question/GetByQuizId/${quizResult.id}`);
      const data = await response.json();
      if (response.ok) {
        setQuizQuestions(data);
        setCurrentQuestion(data[questionNumberTracker].questionContent);
      }
    } catch (err) {
      console.error(err);
    } 
  }


  async function FetchSearchInput() {
    try {
      const response = await fetch(
        `${APIUrl}Quiz/GetQuizByName?name=${props.quizName}`
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
      const response = await fetch(`${APIUrl}Answer/IsCorrect/${quizQuestions[questionNumberTracker].id}`);
      const data = await response.json();

      if(response.ok){
        setCorrectAnswerIds(data);
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
    FetchCorrectAnswers();
  }, [quizQuestions, questionNumberTracker]);

  useEffect(() => {
    if(timeLimit == 0)
    {
      for(let x = questionNumberTracker; x < quizQuestions.length; x++)
      {
          setWrongAnswers((prev) => [...prev, quizQuestions[x].questionContent + " TIME OVER"])
      }

      setEndOfQuiz(true);
    }
    

  }, [timeLimit])

  const handleClick = (e) => {
    
   
    setSelectedAnswers((prev)=> [...prev, e.target.textContent])

    const selectedAnswerText = e.target.textContent;
  
    
    const selectedAnswer = quizAnswers.find((answer) => answer.answerContent === selectedAnswerText);
  
   
    const isCorrect = correctAnswerIds.includes(selectedAnswer.id);
  
    if (isCorrect) {
    
      setPoints((prevPoints) => prevPoints + 1);
      setCorrectAnswers((prev) => [...prev, quizQuestions[questionNumberTracker].questionContent + " " + e.target.textContent]);
    }
    else{
      setWrongAnswers((prev) => [...prev, quizQuestions[questionNumberTracker].questionContent + " " + e.target.textContent]);
    }
  
   
    if (quizQuestions.length - 1 === questionNumberTracker) {
      setEndOfQuiz(true);
    } else {
      setQuestionNumberTracker((prev) => prev + 1);
      setKey(key + 1);
    }
  };

  return (
    <>

      {loading ? <LoadingElement/> : quizQuestions && quizResult && quizAnswers && quizQuestions.length > 0 && quizAnswers.length > 0 && endofQuiz == false ? (
        <div className="maincontainer animated-background">
          <div className="quiz-time-image-container"><img className="quiz-time-image" src={quizImage}></img></div>
          <div className="">
          <CountdownTimer setTimeLimit={setTimeLimit}/>
          </div>
          <div className="quiz-container">
          <div className="quiz-title">{quizResult.quizName}</div>
          <div key={key} className="quiz-question">{currentQuestion}</div>
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

      ) : (
       endofQuiz && <EndQuizElement selectedAnswers = {selectedAnswers} wrongAnswers = {wrongAnswers} correctAnswers={correctAnswers}/>
      )}

    </>
  );
}
