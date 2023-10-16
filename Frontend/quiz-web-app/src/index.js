import React from 'react';
import ReactDOM from 'react-dom/client';
import reportWebVitals from './reportWebVitals';
import {BrowserRouter, createBrowserRouter, RouterProvider, Route} from 'react-router-dom'
import DummyPage from './Pages/DummyPage.jsx'
import NavigationBar from './Components/NavigationBar';
import CategoriesPage from './Pages/CategoriesPage';
import Layout from './Pages/Layout';
import QuizPage from './Pages/QuizPage';

const router = createBrowserRouter([
  {
    path: "/",
    element: <Layout />,
    errorElement: <Layout />,
    
    children: [
      {
        path: "/",
        element: <DummyPage />,
      },
      {
        path: "/categories",
        element: <CategoriesPage />,
      },
      {
        path: "/playQuiz",
        element: <QuizPage />
      }
    ]
  }
]);



const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
   <RouterProvider router={router}/>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
