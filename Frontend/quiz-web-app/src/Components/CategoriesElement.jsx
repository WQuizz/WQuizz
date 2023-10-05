import { useState, useEffect } from "react"
import categoryObjects from "../Files/CategoryObjects.js"
import "../Styles/categorypage.css";

export default function CategoriesElement() {
    const [categories, setCategories] = useState([])

    useEffect(() => {
        fetch("http://localhost:5015/api/Category")
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







