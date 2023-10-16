import { useLocation, useParams } from 'react-router-dom';
import QuizElement from '../Components/QuizElement';
import { useEffect } from 'react';
export default function QuizPage(){

   const {quizName} = useParams();
  
    return (
      <div>
        <QuizElement quizName={quizName} />
      </div>
    );
 }