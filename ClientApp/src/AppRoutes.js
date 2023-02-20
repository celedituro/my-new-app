import { Home } from "./components/Home";
import FetchData from "./components/Home";
import Form from "./components/Form";

const AppRoutes = [
  {
    index: true,
    element: <FetchData />
  },
  {
    path: '/form',
    element: <Form />
  },
];

export default AppRoutes;
