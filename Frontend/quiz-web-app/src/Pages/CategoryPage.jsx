import CategoryElement from "../Components/CategoryElement"
import { useParams } from 'react-router-dom';


export default function CategoryPage(){
  const {categoryName} = useParams();
    return(
        <CategoryElement categoryName={categoryName} />
    )
}