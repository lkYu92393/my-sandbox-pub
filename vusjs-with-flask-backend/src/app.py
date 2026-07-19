from flask import Flask, redirect, request, render_template, jsonify
from random import *

from backend.api import *

app = Flask(__name__,
            static_folder = "./dist/static",
            template_folder = "./dist")

@app.route('/api/progress')
def progress():
    response = get_progress()
    return jsonify(response)

@app.route('/api/random', methods = ['GET'])
def random_number_get():
    response = get_random_record()
    return jsonify(response)

@app.route('/api/random', methods = ['POST'])
def random_number_post():
    add_grading_and_remove_record(request.json["body"])
    return "SUCCESS"

@app.route('/', defaults={'path': ''})
@app.route('/<path:path>')
def catch_all(path):
    return render_template("index.html")