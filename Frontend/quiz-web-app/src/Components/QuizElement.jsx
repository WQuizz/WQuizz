import { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import "../Styles/quizelement.css";
import "../Styles/animated-background.css";
import quizImage from "../Images/quiz-time.png";


export default function QuizElement(props) {
  const [quizResult, setQuizResult] = useState("");




  async function FetchSearchInput() {
    try {
      const response = await fetch(
        `http://localhost:9000/api/Quiz/GetQuizByName?name=${props.quizName}`
      );
      const data = await response.json();
      setQuizResult(data);
      console.log(data);
    } catch (err) {
      console.error(err);
    }
  }

  useEffect(() => {
    FetchSearchInput();
  }, []);

useEffect(()=>{
  console.log(quizResult);
},[quizResult])

  return (
    <>
      {quizResult && (
        <>
        <div className="maincontainer animated-background">
          <div className="quiz-time-image-container"><img className="quiz-time-image" src={quizImage}></img></div>
          <div className="quiz-container">
          <div className="quiz-question">{quizResult.quizName}</div>
          <div className="quiz-answers">
            <div className="answer-row first-row"> 
            <button className="answer">Answer 1</button>
            <button className="answer">Answer 2</button>
            </div>
          <div className="answer-row second-row"> 
          <button className="answer">Answer 3</button>
            <button className="answer">Answer 4</button>
          </div>
          </div>
          </div>
          </div>
        </>
      )}
    </>
  );
}
