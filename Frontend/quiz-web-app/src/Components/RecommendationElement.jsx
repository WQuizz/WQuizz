import "../Styles/recommendationelement.css";
import { useNavigate } from 'react-router-dom';


export default function RecommendationElement(){

    const navigate = useNavigate();

    const handleClick = () => {

        navigate(`/playQuiz/Chemical Symbols`);
    }

    return (
        
          <div className="card text-white bg-dark mb-3 recommendation-element">
            <div className="card-header">Recommendation</div>
            <div className="card-body" onClick={() => handleClick() }>
              <h5 className="card-title">Chemical Symbols🧪</h5>
              <p className="card-text">Check out this awesome quiz if you want to learn more about the chemical symbols!</p>
            </div>
          </div>
      );
}