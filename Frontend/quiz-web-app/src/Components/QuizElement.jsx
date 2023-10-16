import { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";

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

  return (
    <>
      {quizResult && (
        <>
          <h1 style={{ fontSize: 1000, zIndex: 1000000, color: "white" }}>
            {props.quizName}
          </h1>
          <h1>{quizResult.quizName}</h1>
        </>
      )}
    </>
  );
}
