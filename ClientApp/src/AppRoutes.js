import Home from "./components/Home";
import Form from "./components/Form";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/form',
    element: <Form />
  },
];

export default AppRoutes;
