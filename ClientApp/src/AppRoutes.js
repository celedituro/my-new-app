import { Home } from "./components/Home";
import FetchData from "./components/FetchData";
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
  {
    path: '/table',
    element: <FetchData />
  }
];

export default AppRoutes;
