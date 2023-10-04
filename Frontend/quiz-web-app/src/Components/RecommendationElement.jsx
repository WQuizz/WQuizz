import { useState,useEffect } from "react";
import PatchNotesElement from "./PatchNotesElement";
export default function RecommendationElement(){

    const [recommendation, setRecommendation] = useState(null)
   
    const searchValues=["Capital Cities around the world", "Chemical Symbols"]

    // useEffect(() => {
    //     fetch(`http://localhost:9000/api/Quiz/GetRandomApprovedQuiz`)
    //     .then(res => res.text())
    //     .then(text => setRecommendation(text))
    //     .catch((err)=> console.log(err))

    // }, [])  

return(
    <>
     <div className="card text-white bg-dark mb-3 recommendation-element">
        <div className="card-header">Recommendation</div>
            <div className="card-body">
                <h5 className="card-title">Recommended quiz comes here</h5>
                <p className="card-text">Check out this amazing quiz for start!</p>
            </div>
    </div> 
    
    </>
)



}