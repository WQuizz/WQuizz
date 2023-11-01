import { useState, useEffect } from "react"
import categoryObjects from "../Files/CategoryObjects.js"
import "../Styles/categorypage.css";
import { useNavigate } from "react-router-dom"; 
import { APIUrl } from "../Files/APIUrl.js";

export default function CategoriesElement() {

    const navigate = useNavigate();

    const [categories, setCategories] = useState([])

    useEffect(() => {
        fetch(APIUrl + "Category")
            .then(res => res.json())
            .then(category => setCategories(category))
            .catch(error => console.log(error))
    }, [])

    return (
        <>
        <h1 className="category-title">Categories</h1>
        <div className="category-page">
            <div className="flex-container">
                {categories &&
                    categories.map((c, index) => {
                        const matchingCategory = categoryObjects.find(
                            (co) => c.toLowerCase() === co.name.toLowerCase()
                        );
                        if (matchingCategory) {
                            return (<>
                                    
                                    <div className="category-content-wrapper">
                                    <img
                                        className="category-images"
                                        src={matchingCategory.url}
                                        alt={c}
                                        onClick={() => {navigate(`/category/${c}`)}}
                                    ></img><div className="text-section">{c}</div>
                                    </div>
                                    
                            </>);
                        } else {
                            return null; 
                        }
                    })}
            </div>
        </div>
        </>
    );
}







