import React, { useEffect, useState } from "react";
import { APIUrl } from "../Files/APIUrl";
import "../Styles/categorycards.css"
import categoryObjects from "../Files/CategoryObjects.js"
import { Link, useNavigate } from "react-router-dom";

export default function CategoryElement(props){
    const [quizzes, setQuizzes] = useState(null);
    const navigate = useNavigate();
    async function getQuizzes(){
        const response = await fetch(APIUrl + "Category/byName/" + props.categoryName);
        const processedData = await response.json();
        console.log(processedData)
        setQuizzes(processedData)
    }
    const handlePlay = (targetName) => {
        navigate(`/playQuiz/${targetName}`);
    }
    useEffect(() => {
        getQuizzes()
    }, [props.categoryName])
    function buildQuizCards(){
        if(quizzes){
            return quizzes.map((quiz, index) => 
                (<div class="card category-card" key={index}>
                            <img class="card-img-top card-image" src={quiz.thumbnailUrl ? quiz.thumbnailUrl : categoryObjects.find(x => x.name === props.quizName.ToLowerCase()).url} alt="Quiz image"></img>
                            <div class="card-body">
                            <div class="card-text-wrapper"><h2 class="card-title">{quiz.quizName}</h2></div>
                            <div class="card-text-wrapper"><p class="card-text">Lorem Ipsum</p></div>
                            <div class="btn-wrapper"><button class="btn btn-dark" onClick={() => handlePlay(quiz.quizName)}>Play this Quiz</button></div>
                            </div>
                        </div>)
            )
        } 
        else {
            return <h1 style={{ margin: "auto" }}>Loading...</h1>;
        }
    }
    return (
    <div className="card-wrapper">{buildQuizCards()}</div>
    )
}