import DummyText from "../Components/HomeElement"
import {SearchBar} from "../Components/SearchBar"
import "../Styles/homepage.css";
import RecommendationElement from "../Components/RecommendationElement";
import { QuizSlider } from "../Components/QuizSlider";
import PatchNotesElement from "../Components/PatchNotesElement";


export default function DummyPage(){

return(
       
    <div className="Homepage">
        <RecommendationElement />
        <DummyText/>
        <SearchBar/>
        <QuizSlider/>
        <PatchNotesElement/>
    </div>

    )
}


