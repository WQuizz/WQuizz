import { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import "../Styles/quizelement.css";
import "../Styles/animated-background.css";
import "../Styles/endquizelement.css";
import quizImage from "../Images/quiz-time.png";



export default function EndQuizElement(props)
{

    const [showCorrectAnswers, setShowCorrectAnswers] = useState(false);
    const [showIncorrectAnswers, setShowIncorrectAnswers] = useState(false);


    const correctLength = props.correctAnswers.length;
    const wrongLength = props.wrongAnswers.length
    const totalLength = props.correctAnswers.length + props.wrongAnswers.length;

    return (
        <>
       <div className="end-quiz-container animated-background">
        <div className="result-container">
        <div className="progress">
        <div className="progress-bar bg-success" role="progressbar" style={{ width: `${(correctLength / totalLength) * 100}%` }} aria-valuenow={(correctLength / totalLength * 100).toString()} aria-valuemin="0" aria-valuemax="100">
        Correct: {(correctLength / totalLength * 100)}%
        </div>
        <div className="progress-bar bg-danger" role="progressbar" style={{ width: `${(wrongLength / totalLength) * 100}%` }} aria-valuenow={(wrongLength / totalLength * 100).toString()} aria-valuemin="0" aria-valuemax="100">
         Incorrect: {(wrongLength / totalLength * 100)}%
        </div>
        </div>

        <div className="card">
            <div className="card-body">
                <h5 className="card-title">Quiz Results</h5>
                    <p className="card-text">
                        Correct Answers: <span className="badge badge-success">{correctLength}</span>
                        <button className="btn btn-link" onClick={() => setShowCorrectAnswers(!showCorrectAnswers)}>Show Correct Answers</button>
                    </p>
                    {showCorrectAnswers && (
                <ul>
                  {props.correctAnswers.map((answer, index) => (
                    <li key={index}>{answer}</li>
                  ))}
                </ul>
              )}
                    <p className="card-text">
                        Incorrect Answers: <span className="badge badge-danger">{wrongLength}</span>
                        <button className="btn btn-link" onClick={() => setShowIncorrectAnswers(!showIncorrectAnswers)}>Show Incorrect Answers 🦧</button>
                    </p>
                    {showIncorrectAnswers && (
                        <ul>
                            {props.wrongAnswers.map((answer, index) => (
                                <li key={index}>{answer}</li>
                            ))}
                        </ul>
                    )} 
            </div>
        </div>
        </div>
        </div>
       </>
    )




}