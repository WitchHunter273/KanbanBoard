import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface DataFromDb {
    tasks: Tasks[];
    loading: boolean;
}

export class TasksData extends React.Component<RouteComponentProps<{}>, DataFromDb> {


    delete(item: Tasks) {
        const newState = this.state.tasks;
        newState.splice(newState.indexOf(item), 1);
        this.setState({ tasks: newState })

        fetch('api/DataEventRecords/' + item.id, {
            method: 'delete'
        }
        );
    }

    constructor() {
        super();
        this.state = { tasks: [], loading: true };

        fetch('api/DataEventRecords/GetTasks')
            .then(response => response.json() as Promise<Tasks[]>)
            .then(data => {
                this.setState({ tasks: data, loading: false });
            });
    }



    public render() {
        let contents =
            <table className='table'>
                <thead>
                    <th>ID</th>
                    <th>Titel</th>
                    <th>Description</th>
                    <th>Case</th>
                </thead>
                <tbody> {this.state.tasks.map(tasks =>
                    <tr>
                        <td>{tasks.id}</td>
                        <td>{tasks.title}</td>
                        <td>{tasks.description}</td>
                        <td>{tasks.caseType}</td>
                        <td> <button onClick={this.delete.bind(this, tasks)} >Delete</button></td>

                    </tr>
                )}
                </tbody>
            </table>;

        return <div>
            {contents}
        </div>;
    }

}


interface Tasks {
    id: number;
    title: string;
    description: string;
    caseType: string;
}
