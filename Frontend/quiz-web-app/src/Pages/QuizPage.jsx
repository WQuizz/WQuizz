import { useLocation } from 'react-router-dom';

export default function QuizPage(){

    const location = useLocation();
    const quizName = location.state.quizName;
  
    return (
      <div>
        <QuizElement quizName={quizName} />
      </div>
    );
 }