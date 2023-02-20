import Home from "./components/Home";
import Form from "./components/Form";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/signup',
    element: <Form />
  },
];

export default AppRoutes;
