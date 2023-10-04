import DummyText from "../Components/DummyText"
import {SearchBar} from "../Components/SearchBar"
import "../Styles/homepage.css";
import NavigationBar from "../Components/NavigationBar.jsx"
import Sidebar from "../Components/Sidebar";
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
        <Sidebar />
        <PatchNotesElement/>
    </div>

    )
}


