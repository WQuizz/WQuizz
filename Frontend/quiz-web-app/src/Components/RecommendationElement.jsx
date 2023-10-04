import { useState,useEffect } from "react";

export default function RecommendationElement(){

    const [recommendation, setRecommendation] = useState(null)
   
    const searchValues=["Capital Cities around the world", "Chemical Symbols"]

    useEffect(() => {
        fetch(`http://localhost:5015/api/Quiz/GetQuizzesContaining?searchTerm=${searchValues[Math.random()*searchValues.length]}`)
        .then(res => res.text())
        .then(text => setRecommendation(text))
        .catch((err)=> console.log(err))

    }, [])  

return(
    <div>
        {recommendation}
    </div>
)



}