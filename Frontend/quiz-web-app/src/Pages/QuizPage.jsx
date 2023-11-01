import { useParams } from 'react-router-dom';
import StartQuizElement from '../Components/StartQuizElement';
export default function QuizPage(){

   const {quizName} = useParams();
  
    return (
      <div>
        <StartQuizElement quizName={quizName} />
      </div>
    );
 }