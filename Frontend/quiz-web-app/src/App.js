import React, { useState, useEffect } from 'react';
import ReactDOM from 'react-dom/client';
import reportWebVitals from './reportWebVitals';
import {BrowserRouter, createBrowserRouter, RouterProvider, Route} from 'react-router-dom'
import DummyPage from './Pages/DummyPage.jsx'
import NavigationBar from './Components/NavigationBar';
import CategoriesPage from './Pages/CategoriesPage';
import CategoryPage from './Pages/CategoryPage';
import Layout from './Pages/Layout';
import RegisterPage from './Pages/RegisterPage';
import LoginPage from './Pages/LoginPage';
import QuizPage from './Pages/QuizPage';
import Cookies from 'universal-cookie';



function App() {
  const [loggedIn, setLoggedIn] = useState(false);
  const cookies = new Cookies();
  const logOut = () => {
      cookies.remove("jwt_authorization");
      console.log("logout");
      setLoggedIn(false);
    }

    useEffect(() => {
      // Check if the jwt_authentication cookie exists
      const jwtToken = cookies.get("jwt_authorization");
      if (jwtToken) {
        // If the cookie exists, consider the user as logged in
        setLoggedIn(true);
      }
    }, []);

  const router = createBrowserRouter([
    {
      path: "/",
      element: <Layout loggedIn={loggedIn} logOut={logOut}/>,
      errorElement: <Layout loggedIn={loggedIn} logOut={logOut}/>,
      children: [
        {
          path: "/",
          element: <DummyPage />,
        },
        {
          path: "/categories",
          element: <CategoriesPage />
        },
        {
          path: "/registration",
          element: <RegisterPage loggedIn={loggedIn}/>
        },
        {
          path: "/login",
          element: <LoginPage setLoggedIn={setLoggedIn} loggedIn={loggedIn}/>
        },
        {
          path: "/playQuiz/:quizName",
          element: <QuizPage />
        },
        {
          path: "/category/:categoryName",
          element: <CategoryPage />
        }
      ]
    }
  ]);
  

  return(
    <React.StrictMode>
      <RouterProvider router={router} />
    </React.StrictMode>
  );
}
  
export default App;
