import { Container, Header } from "semantic-ui-react";
import CreateTodo from "./Components/CreateTodo";
import GetTodo from "./Components/GetTodo";
import "./styles/app.css";

function App() {
  return (
    <>
      <div className="main">
        <Container>
          <Header as="h2" textAlign="center">
            .NET REACT CRUD
          </Header>

          <CreateTodo></CreateTodo>
          <GetTodo></GetTodo>
        </Container>
      </div>
    </>
  );
}

export default App;
