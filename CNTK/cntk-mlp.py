#import matplotlib.image as mpimg
import matplotlib.pyplot as plt
import numpy as np
import sys
import os.path

import cntk as C
import cntk.tests.test_utils

#img = Image(url= "data\MNIST\num.png", width=200, height=200);

# Define the data dimensions
input_dim = 1000 #1000
num_output_classes = 1 # 1 Bot/Benign


# Ensure the training and test data is generated and available for this tutorial.
# We search in two locations in the toolkit for the cached MNIST data set.
data_found = False
train_file = os.path.join("[PATH]", "CNTK_NN_Full_b_clean.txt")
test_file = os.path.join("[PATH]", "CNTK_NN_Test_c_clean.txt")
if os.path.isfile(train_file) and os.path.isfile(test_file):
    data_found = True
if not data_found:
    raise ValueError("CTF data not yet generated")
print("Data directory is {0}".format(data_dir))

num_hidden_layers = 100
hidden_layers_dim = 100

input = C.input_variable(1000)
label = C.input_variable(num_output_classes)

# Read a CTF formatted text (as mentioned above) using the CTF deserializer from a file
def create_reader(path, is_training, input_dim, num_label_classes):
    return C.io.MinibatchSource(C.io.CTFDeserializer(path, C.io.StreamDefs(
        labels = C.io.StreamDef(field='labels', shape=1, is_sparse=False),
        features   = C.io.StreamDef(field='features', shape=1000, is_sparse=False)
    )), randomize = is_training, max_sweeps = C.io.INFINITELY_REPEAT if is_training else 1)



def create_model(features):
    with C.layers.default_options(init = C.layers.glorot_uniform(), activation = C.ops.leaky_relu):
            f = features
            #for _ in range(num_hidden_layers):
            h1 = C.layers.Dense(30, activation = C.ops.leaky_relu)(f)  
            h2 = C.layers.Dense(30, activation = C.ops.leaky_relu)(h1)
            h3 = C.layers.Dense(30, activation = C.ops.leaky_relu)(h2)  
            h4 = C.layers.Dense(30, activation = C.ops.leaky_relu)(h3)
            h5 = C.layers.Dense(30, activation = C.ops.leaky_relu)(h4)  
            h6 = C.layers.Dense(30, activation = C.ops.leaky_relu)(h5)          

            r = C.layers.Dense(1)(h6)
            return r
        

train = create_reader(train_file, True , 1000 , 1)


# Map the data streams to the input and labels.
input_map = {
    label  : train.streams.labels,
    input  : train.streams.features
} 

#input = np.array(input_map)

#input = C.input_variable(1000)
#label = C.input_variable(num_output_classes)

z = create_model(input)


loss = C.cross_entropy_with_softmax(z, label)

label_error = C.squared_error(z, label)

# Instantiate the trainer object to drive the model training
learning_rate = 0.8
lr_schedule = C.learning_parameter_schedule(learning_rate)
learner = C.adadelta(z.parameters, lr_schedule)
trainer = C.Trainer(z, (loss, label_error), [learner])

# Define a utility function to compute the moving average sum.
# A more efficient implementation is possible with np.cumsum() function
def moving_average(a, w=5):
    if len(a) < w:
        return a[:]    # Need to send a copy of the array
    return [val if idx < w else sum(a[(idx-w):idx])/w for idx, val in enumerate(a)]


# Defines a utility that prints the training progress
def print_training_progress(trainer, mb, frequency, verbose=1):
    loss = "NA"
    error = "NA"

    if mb%frequency == 0:
        loss = trainer.previous_minibatch_loss_average
        error = trainer.previous_minibatch_evaluation_average
        if verbose: 
            print ("Minibatch: {0}, Loss: {1:.4f}, Error: {2:.2f}%".format(mb, loss, error*100))
        
    return mb, loss, error


# Initialize the parameters for the trainer
minibatch_size = 100
num_samples_per_sweep = 1000
num_sweeps_to_train_with =10
num_minibatches_to_train = (num_samples_per_sweep * num_sweeps_to_train_with) / minibatch_size     

#(num_samples_per_sweep * num_sweeps_to_train_with) / minibatch_size

# Create the reader to training data set
reader_train = create_reader(train_file, "true", 1, 1)

# Run the trainer on and perform model training
training_progress_output_freq = 0.5

plotdata = {"batchsize":[], "loss":[], "error":[]}



for i in range(0, int(2000)):
    
    # Map the data streams to the input and labels.
    input_map = {
         label : reader_train.streams.labels,
         input : reader_train.streams.features
    } 

    
    # Read a mini batch from the training data file
    data = reader_train.next_minibatch(600, input_map = input_map)
    #print(data)

    test = data.get('MinibatchData')

    trainer.train_minibatch(data)
    batchsize, loss, error = print_training_progress(trainer, i, training_progress_output_freq, verbose=1)
    
    if not (loss == "NA" or error =="NA"):
        plotdata["batchsize"].append(batchsize)
        plotdata["loss"].append(loss)
        plotdata["error"].append(error)

# Compute the moving average loss to smooth out the noise in SGD
plotdata["avgloss"] = moving_average(plotdata["loss"])
plotdata["avgerror"] = moving_average(plotdata["error"])

# Plot the training loss and the training error
import matplotlib.pyplot as plt

plt.figure(1)
plt.subplot(211)
plt.plot(plotdata["batchsize"], plotdata["avgloss"], 'b--')
plt.xlabel('Minibatch number')
plt.ylabel('Loss')
plt.title('Minibatch run vs. Training loss')

plt.show()

plt.subplot(212)
plt.plot(plotdata["batchsize"], plotdata["avgerror"], 'r--')
plt.xlabel('Minibatch number')
plt.ylabel('Label Prediction Error')
plt.title('Minibatch run vs. Label Prediction Error')
plt.show()


# Read the training data
reader_train = create_reader(train_file, True, input_dim, num_output_classes)

train_input_map = {
    label  : reader_train.streams.labels,
    input  : reader_train.streams.features,
}

#x = C.input_variable(z.parameters)


netout = z
y = create_model(netout) #user-defined 



# Test data for trained model
test_minibatch_size = 5000
num_samples = 5000
num_minibatches_to_test = num_samples // test_minibatch_size
test_result = 0.0


# Read the test data
reader_test = create_reader(test_file, False, input_dim, num_output_classes)

test_input_map = {
    label  : reader_test.streams.labels,
    input  : reader_test.streams.features,
}


training_progress_output_freq = 0.5


for j in range(num_minibatches_to_test):
    
    # We are loading test data in batches specified by test_minibatch_size
    # Each data point in the minibatch is a MNIST digit image of 784 dimensions 
    # with one pixel per dimension that we will encode / decode with the 
    # trained model.
    data = reader_test.next_minibatch(test_minibatch_size,
                                      input_map = test_input_map)

    

    batchsize, loss, error = print_training_progress(trainer, j, training_progress_output_freq, verbose=1)
    
    if not (loss == "NA" or error =="NA"):
        plotdata["batchsize"].append(batchsize)
        plotdata["loss"].append(loss)
        plotdata["error"].append(error)

    eval_error = trainer.test_minibatch(data)
    test_result = test_result + eval_error

# Compute the moving average loss to smooth out the noise in SGD
plotdata["avgloss"] = moving_average(plotdata["loss"])
plotdata["avgerror"] = moving_average(plotdata["error"])

# Plot the training loss and the training error
import matplotlib.pyplot as plt

plt.figure(1)
plt.subplot(211)
plt.plot(plotdata["batchsize"], plotdata["avgloss"], 'b--')
plt.xlabel('Minibatch number')
plt.ylabel('Loss')
plt.title('Minibatch run vs. Training loss')

plt.show()

plt.subplot(212)
plt.plot(plotdata["batchsize"], plotdata["avgerror"], 'r--')
plt.xlabel('Minibatch number')
plt.ylabel('Label Prediction Error')
plt.title('Minibatch run vs. Label Prediction Error')
plt.show()

# Average of evaluation errors of all test minibatches
print("Average test error: {0:.2f}%".format(test_result*100 / num_minibatches_to_test))

print("Finish")
y.save("cntk-mlp.onnx", format=C.ModelFormat.ONNX)
