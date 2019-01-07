import React, { Component } from 'react';
import axios from 'axios';

import classNames from 'classnames'
import Dropzone from 'react-dropzone'


export class Home extends Component {
  static displayName = Home.name;
  state = {

  }
  
  onDrop = files => {
    console.log({ files })
    // Push all the axios request promise into a single array
    const uploaders = files.map(file => {
      // Initial FormData
      const formData = new FormData();
      formData.append("file", file);
      formData.append("timestamp", (Date.now() / 1000) | 0);
      
      // Make an AJAX upload request using Axios (replace Cloudinary URL below with your own)
      return axios.post("/api/image", formData, {
        headers: { 
          "content-type": "multipart/form-data",
          "accept" : "application/json"
         },
      }).then(response => {
        console.log({response});
      })
    });
  
    // Once all the files are uploaded 
    axios.all(uploaders).then(() => {
     console.log("done");
    });
  }


  render() {

    return (
      <div>
        <Dropzone onDrop={this.onDrop}>
          {({ getRootProps, getInputProps, isDragActive }) => {
            return (
              <div
                {...getRootProps()}
                className={classNames('dropzone', { 'dropzone--isActive': isDragActive })}
              >
                <input {...getInputProps()} />
                {
                  isDragActive ?
                    <p>Drop files here...</p> :
                    <p>Try dropping some files here, or click to select files to upload.</p>
                }
              </div>
            )
          }}
        </Dropzone>

      </div>
    );
  }
}
