import DummyText from "../Components/DummyText"
import {SearchBar} from "../Components/SearchBar"
import "../Styles/homepage.css";
import NavigationBar from "../Components/NavigationBar.jsx"
import Sidebar from "../Components/Sidebar";

export default function DummyPage(){

return(
       
    <div className="Homepage">
        
        <DummyText/>
        <SearchBar/>
        <Sidebar />
    </div>

    )
}


