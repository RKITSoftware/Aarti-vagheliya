import {
    handleOnContentReady, handleOnDisposing, handleOnInitialized, handleOnOptionChanged, handleOnValueChanged
} from "../Event.js";


$(() => {

    $('#simpleFileUpload').dxFileUploader({
        accept: '*',
        activeStateEnabled: true,
        allowCanceling: true,
        allowedFileExtensions: [".jpg", ".png", ".pdf"],
        //dialogTrigger
        disabled: false,
        dropZone: '#drop-zone',
        elementAttr: {
            id: "simpleFileUpload"
        },
        focusStateEnabled: true,
        hint: 'Upload image/pdf file.',
        hoverStateEnabled: true,
        invalidFileExtensionMessage: " This extension not allowed.",
        invalidMaxFileSizeMessage: 'File size is too large.',
        invalidMinFileSizeMessage: 'File size is too small.',
        readyToUploadMessage : 'File is ready to upload',
        uploadAbortedMessage : 'File aborted.',
        uploadedMessage : 'File uploaded.',
        uploadFailedMessage : 'Failed to upload.',
        uploadMethod : "POST", // 'POST','PUT'
        uploadMode : 'useButtons', //  'instantly' | 'useButtons' | 'useForm'
        labelText: 'Drop file here',
        minFileSize: 1024, // 1 KB
        maxFileSize: 1024 * 1024, // 1 MB
        multiple: true,
        uploadUrl: 'https://js.devexpress.com/Demos/NetCore/FileUploader/Upload',
        selectButtonText : 'Select File/files',
        progress : 100,
        showFileList : true,
        uploadButtonText : 'Upload',
        onContentReady: handleOnContentReady,
        onDisposing: handleOnDisposing,
        onInitialized: handleOnInitialized,
        onOptionChanged: handleOnOptionChanged,
        onValueChanged : handleOnValueChanged,
        onBeforeSend: function () {
            console.log("File is ready to upload.");
        },
        onDropZoneEnter: function () {
            console.log("File is entered in drop zone area.");
        },
        onDropZoneLeave: function () {
            console.log("pointer leaves the drop zone area.");
        },
        onFilesUploaded: function (e) {
            console.log("Files uploaded event triggered:", e); // Log the event to debug
            const files = e.component.option("value"); // Retrieve the uploaded files
            console.log("Uploaded files:", files);

            const fileDetailsDiv = $("#file-details");
            fileDetailsDiv.html(""); // Clear previous details

            if (files.length > 0) {
                fileDetailsDiv.append("<h3>Uploaded Files Details:</h3>");
                const list = $("<ul>");
                files.forEach(file => {
                    const fileName = file.name;
                    const fileSize = file.size;
                    const fileType = file.type || "Unknown type";

                    const listItem = $("<li>").text(`Name: ${fileName}, Size: ${fileSize} bytes, Type: ${fileType}`);
                    list.append(listItem);
                });
                fileDetailsDiv.append(list);
            } else {
                fileDetailsDiv.append("<p>No files uploaded.</p>");
            }
        },
        onProgress: function (e) {
            const chunkSize = 2000000; // Size in bytes for each chunk, example: 2MB
            const uploadedBytes = e.segmentSize;
            const totalBytes = e.bytesTotal;
            const uploadedChunks = Math.ceil(uploadedBytes / chunkSize);
            const totalChunks = Math.ceil(totalBytes / chunkSize);

            const chunkInfo = `
                <p>Uploaded Chunks: ${uploadedChunks} / ${totalChunks}</p>
                <p>Chunk Size: ${(chunkSize / 1024).toFixed(2)} KB</p>
                <p>Uploaded Bytes: ${(uploadedBytes / 1024).toFixed(2)} KB</p>
                <p>Total Bytes: ${(totalBytes / 1024).toFixed(2)} KB</p>
            `;
            $('#chunkDetails').html(chunkInfo);
        },
        onUploadAborted: function () {
            console.log("Upload fail.");
        }, 
        onUploaded: function (e) {
            console.log('file uploaded : ',e);
        },
        onUploadError: function (e) {
            console.log('Upload error:', e);
        },
        onUploadStarted: function (e) {
            console.log('Upload started:', e);
        },
        onDropZoneEnter : function(){
            console.log("file enter in dropzone area.");
        },
        onDropZoneLeave :  function(){
            console.log("Leave drop zone area.");
        },
    });


    // const fileUploaderWidget = $('#fileUploader').dxFileUploader({
    //     accept: '*',
    //     allowCanceling: true,
    //     uploadMode: 'useButtons', // useButtons, instantly, useForm
    //     chunkSize: 2000000, // Size in bytes for each chunk, example: 2MB
    //     allowedFileExtensions: ['.jpg', '.jpeg', '.gif', '.png'], // Specify allowed file extensions
    //     invalidMaxFileSizeMessage: 'Itna Zyada kam mat kr yaar, thodi chhoti file daal !!!',
    //     invalidMinFileSizeMessage: 'Thodi badi file daal !!!',
    //     labelText: 'File Ko Utha ke Idhar rakh de 😊😊😊',
    //     multiple: true,
    //     uploadAbortedMessage: 'File Upload nahi krni ',
    //     maxFileSize: 4000000, // Maximum file size in bytes, example: 4MB
    //     onBeforeSend: function (e) {
    //         console.log('Befoile uploaded:', e);
    //         const file = e.file;
    //         const fileInfo = `
    //             <p>File Name: ${file.name}</p>
    //             <p>File Size: ${(file.size / 1024).toFixed(2)} KB</p>
    //             <p>File Type: ${file.type}</p>
    //         `;
    //         $('#fileDetaire sending:', e);
    //     },
    //     onUploadAborted: function (e) {
    //         console.log('Upload aborted:', e);
    //     },
    //     onUploaded: function (e) {
    //         console.log('Fls').html(fileInfo);
    //     },
    //     onUploadError: function (e) {
    //         console.log('Upload error:', e);
    //     },
    //     onUploadStarted: function (e) {
    //         console.log('Upload started:', e);
    //     },
    //     onProgress: function (e) {
    //         const chunkSize = 2000000; // Size in bytes for each chunk, example: 2MB
    //         const uploadedBytes = e.segmentSize;
    //         const totalBytes = e.bytesTotal;
    //         const uploadedChunks = Math.ceil(uploadedBytes / chunkSize);
    //         const totalChunks = Math.ceil(totalBytes / chunkSize);

    //         const chunkInfo = `
    //             <p>Uploaded Chunks: ${uploadedChunks} / ${totalChunks}</p>
    //             <p>Chunk Size: ${(chunkSize / 1024).toFixed(2)} KB</p>
    //             <p>Uploaded Bytes: ${(uploadedBytes / 1024).toFixed(2)} KB</p>
    //             <p>Total Bytes: ${(totalBytes / 1024).toFixed(2)} KB</p>
    //         `;
    //         $('#chunkDetails').html(chunkInfo);
    //     },
    //     uploadButtonText: 'Ghusa Do !!!',
    //     uploadFailedMessage: 'Nahi Daal Paya 🥺🥺🥺',
    //     uploadedMessage: 'Kaam Ho Gaya 🥳🥳🥳',
    //     showFileList: true,
    //     selectButtonText: 'File Leke Aa Chal',
    //     readyToUploadMessage: 'Daal du ???',
    //     invalidFileExtensionMessage: 'Ye Extension wali file nahi chalegi BRO !!!!',
    //    // uploadUrl: 'https://js.devexpress.com/Demos/NetCore/FileUploader/Upload',
    // }).dxFileUploader('instance');
});