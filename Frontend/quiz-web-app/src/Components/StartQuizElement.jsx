import { useEffect, useState } from "react";
import QuizElement from "./QuizElement";
import "../Styles/startquizelement.css";
import "../Styles/animated-background.css";

export default function StartQuizElement(props)
{

const [startGame, setStartGame] = useState(false);

const handleClick = () => {
    setStartGame(true);
}


return (
    <>
      {!startGame ? (
        <div className="animated-background">
          <div className="main-container">
            <div className="card text-white bg-success mb-3 quiz-description">
              <div className="card-header">Quiz description</div>
              <div className="card-body">
                <h4 className="card-title">{props.quizName}</h4>
                <p className="card-text">Every question has 1 possible answer.</p>
                <p className="card-text">You will have 30 seconds to finish 4 questions.</p>
              </div>
              <button className="btn btn-warning" onClick={() => handleClick()}>
                Start Quiz!
              </button>
            </div>
          </div>
        </div>
      ) : (
        <>
          <QuizElement quizName={props.quizName}/>
        </>
      )}
    </>
  );
}