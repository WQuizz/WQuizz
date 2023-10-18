import { useLocation, useParams } from 'react-router-dom';
import QuizElement from '../Components/QuizElement';
import { useEffect } from 'react';
import StartQuizElement from '../Components/StartQuizElement';
export default function QuizPage(){

   const {quizName} = useParams();
  
    return (
      <div>
        <StartQuizElement quizName={quizName} />
      </div>
    );
 }