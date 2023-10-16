import { useState, useEffect } from "react";

export default function QuizElement(props){

    const [quizResult, setQuizResult] = useState("");

    async function FetchSearchInput()
    {
        try{
            const response = await fetch(`http://localhost:9000/api/Quiz/GetQuizByName/${props.quizName}`)
            const data = await response.json();
            setQuizResult(data);

        }catch(err)
        {
            console.error(err);
        }
    }

    useEffect(() => {
        
        FetchSearchInput();

    }, [])


    return(
        <>
        <h1>{props.quizName}</h1>
        <h1>{quizResult.QuizName}</h1>
        
        </>
    )



}