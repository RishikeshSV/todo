import React, { useState, useEffect } from "react";
import { Button, Table } from "semantic-ui-react";
import api from "../api/requests";

const GetTodo = () => {
  const [todos, setTodos] = useState([]);

  useEffect(() => {
    const fetchTodos = async () => {
      const request = await api.get("/todo");
      setTodos(request.data);
    };
    fetchTodos();
  }, [todos]);

  //DELETE TASK
  const deleteTask = async (id) => {
    try {
      await api.delete(`/todo/${id}`);
    } catch (err) {
      console.log(err.response.data.title);
    }
  };
  //UPDATE TASK ON COMPLETION
  const updateTask = async (id, task) => {
    try {
      const status = true;
      await api.put(`/todo/${id}`, { id, task, status });
    } catch (err) {
      console.log(err.response.data.title);
    }
  };

  return (
    <>
      <Table basic="very" unstackable fixed striped>
        <Table.Header>
          <Table.Row>
            <Table.HeaderCell width={6}>TASK</Table.HeaderCell>
            <Table.HeaderCell width={3}>STATUS</Table.HeaderCell>
            <Table.HeaderCell width={3}>REMOVE</Table.HeaderCell>
          </Table.Row>
        </Table.Header>

        <Table.Body>
          {todos.map((todo) => {
            return (
              <Table.Row key={todo.id}>
                <Table.Cell>{todo.task}</Table.Cell>
                <Table.Cell>
                  {todo.status ? (
                    <Button icon="check" color="green" />
                  ) : (
                    <Button
                      icon="history"
                      color="yellow"
                      onClick={() => updateTask(todo.id, todo.task)}
                    />
                  )}
                </Table.Cell>
                <Table.Cell>
                  <Button
                    icon="times"
                    color="red"
                    onClick={() => deleteTask(todo.id)}
                  />
                </Table.Cell>
              </Table.Row>
            );
          })}
        </Table.Body>
      </Table>
    </>
  );
};

export default GetTodo;
