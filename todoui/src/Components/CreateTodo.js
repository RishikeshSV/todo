import React, { useState } from "react";
import { Button, Form, Header, Icon } from "semantic-ui-react";
import api from "../api/requests";

const CreateTodo = () => {
  const [task, setTask] = useState("");

  const addTask = async (e) => {
    setTask("");
    document.querySelector(".task-input").value = "";
    try {
      const status = false;
      await api.post("/todo", { task, status });
    } catch (err) {
      console.log(err.response.data.title);
    }
  };

  return (
    <>
      <Header className="form-title" as="h3">
        <Icon name="list ul" />
        <Header.Content>
          TASK
          <Header.Subheader>Create a task</Header.Subheader>
        </Header.Content>
      </Header>
      <Form className="newTask" onSubmit={addTask}>
        <Form.Group>
          <Form.Field className="task-item">
            <input
              className="task-input"
              placeholder="Enter your task"
              onChange={(e) => setTask(e.target.value)}
              required
            />
          </Form.Field>
          <Button className="submit-button" type="submit">
            ADD TASK
          </Button>
        </Form.Group>
      </Form>
    </>
  );
};

export default CreateTodo;
