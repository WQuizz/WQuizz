import ourLogo from '../Images/ourlogo.png';
import '../Styles/homepage.css';


export default function HomeElement(){
   
    return(
        <>
        <div>
            <img src={ourLogo} className='homeImage'></img> 
        </div>
        </>
    )
}