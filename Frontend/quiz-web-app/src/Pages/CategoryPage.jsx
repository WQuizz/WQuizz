import CategoryElement from "../Components/CategoryElement"
import { useParams } from 'react-router-dom';


export default function CategoriesPage(){
  const {categoryName} = useParams();
    return(
        <CategoryElement categoryName={categoryName} />
    )
}