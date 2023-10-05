import { useState, useEffect } from "react"
import categoryObjects from "../Files/CategoryObjects.js"

export default function CategoriesElement() {
    const [categories, setCategories] = useState([])

    useEffect(() => {
        fetch("http://localhost:9000/api/Category")
            .then(res => res.json())
            .then(category => setCategories(category))
            .catch(error => console.log(error))
    }, [])

    return (
        <>
            {categories && categories.map((c, index) => {
                const matchingCategory = categoryObjects.find(co => c.toLowerCase() === co.name.toLowerCase());
                if (matchingCategory) {
                    return (
                        <div key={index}>
                            {c}
                            <img src={matchingCategory.url} alt={c} />
                        </div>
                    );
                } else {
                    return null; // Or handle the case where no matching category is found
                }
            })}
        </>
    )
}






